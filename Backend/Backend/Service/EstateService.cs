using Backend.Models.Entity;
using Backend.Models;
using Backend.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Service
{
    public class EstateService
    {
        private readonly MaindbContext _context;

        public EstateService(MaindbContext context)
        {
            _context = context;
        }

        public Estate GetEstate(string estateId)
        {
            try
            {
                var estate = (from e in _context.EpEstates
                              where e.EstateId == estateId && e.IsDelete == false
                              join d in _context.EpEstateDetails on e.EstateId equals d.EstateId into details
                              from detail in details.DefaultIfEmpty()
                              select new Estate
                              {
                                  EstateId = e.EstateId,
                                  EstatePrice = e.EstatePrice,
                                  EmployeeId = e.EmployeeId,
                                  EstateAddress = e.EstateAddress,
                                  EstateAge = e.EstateAge,
                                  EstateAnnualTax = e.EstateAnnualTax,
                                  EstateCity = e.EstateCity,
                                  EstateDescription = e.EstateDescription,
                                  EstateSizeSqft = e.EstateSizeSqft,
                                  EstateState = e.EstateState,
                                  EstateType = e.EstateType,
                                  EstateZip = e.EstateZip,
                                  IsDelete = e.IsDelete,
                                  Timestamp = e.Timestamp,
                                  estateDetail =
                                  {
                                      EstateId = estateId,
                                      DetailId = detail.DetailId,
                                      DetailLatitude = detail.DetailLatitude,
                                      DetailNumBathroom = detail.DetailNumBathroom, 
                                      DetailNumBedroom = detail.DetailNumBedroom,
                                      DetailNumGarage = detail.DetailNumGarage,
                                      IsDelete = detail.IsDelete,
                                      Timestamp = detail.Timestamp,
                                  },
                                  estateImgList = _context.EpEstateImgs
                                                         .Where(img => img.EstateId == estateId)
                                                         .ToList()
                              }).FirstOrDefault();

                if (estate == null)
                {
                    throw new Exception($"Cannot find estate with ID {estateId}");
                }

                return estate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching estate: {ex.Message}");
                throw;
            }
        }

        public Estate UpdateEstate(Estate estate)
        {
            try
            {
                // CREATE new estate
                if (string.IsNullOrEmpty(estate.EstateId))
                {
                    var EstateId = GenerateEstateId();
                    var epEstate = new EpEstate
                    {
                        EstateId = EstateId,
                        EstateAddress = estate.EstateAddress,
                        EstateCity = estate.EstateCity,
                        EstateState = estate.EstateState,
                        EstateZip = estate.EstateZip,

                        EstateType = estate.EstateType,
                        EstateAge = estate.EstateAge,
                        EstateSizeSqft = estate.EstateSizeSqft,

                        EstatePrice = estate.EstatePrice,
                        EstateAnnualTax = estate.EstateAnnualTax,
                        EstateDescription = estate.EstateDescription,

                        EmployeeId = estate.EmployeeId,
                        IsDelete = false,
                        Timestamp = DateTime.Now
                    };

                    _context.EpEstates.Add(epEstate);
                    _context.SaveChanges();

                    // 2. Save estate details
                    if (estate.estateDetail != null)
                    {
                        EpEstateDetail epEstateDetail = new EpEstateDetail();
                        epEstateDetail.EstateId = EstateId;
                        epEstateDetail.DetailNumGarage = estate.estateDetail.DetailNumGarage;
                        epEstateDetail.DetailLatitude = estate.estateDetail.DetailLatitude;
                        epEstateDetail.DetailNumBathroom = estate.estateDetail.DetailNumBathroom;
                        epEstateDetail.DetailNumBedroom = estate.estateDetail.DetailNumBedroom;
                        epEstateDetail.IsDelete = false;
                        epEstateDetail.Timestamp = DateTime.Now;
                        _context.EpEstateDetails.Add(epEstateDetail);
                        _context.SaveChanges();
                    }

                    // Return estate with the generated ID
                    estate.EstateId = epEstate.EstateId;
                }
                else
                {
                    var epEstate = _context.EpEstates.Where(x=>x.EstateId == estate.EstateId).FirstOrDefault();
                    if (epEstate == null)
                    {
                        throw new Exception("can not match in db");
                    }

                    epEstate.EstateAddress = estate.EstateAddress;
                    epEstate.EstateCity = estate.EstateCity;
                    epEstate.EstateState = estate.EstateState;
                    epEstate.EstateZip = estate.EstateZip;

                    epEstate.EstateType = estate.EstateType;
                    epEstate.EstateAge = estate.EstateAge;
                    epEstate.EstateSizeSqft = estate.EstateSizeSqft;

                    epEstate.EstatePrice = estate.EstatePrice;
                    epEstate.EstateAnnualTax = estate.EstateAnnualTax;
                    epEstate.EstateDescription = estate.EstateDescription;

                    epEstate.EmployeeId = estate.EmployeeId;
                    epEstate.IsDelete = false;
                    epEstate.Timestamp = DateTime.Now;

                    var epEstateDetail = _context.EpEstateDetails.Where(x => x.EstateId == estate.EstateId).FirstOrDefault();
                    if(epEstateDetail != null && estate.estateDetail!=null)
                    {
                        epEstateDetail.DetailLatitude = estate.estateDetail.DetailLatitude;
                        epEstateDetail.DetailNumGarage = estate.estateDetail.DetailNumGarage;
                        epEstateDetail.DetailNumBathroom = estate.estateDetail.DetailNumBathroom;
                        epEstateDetail.DetailNumBedroom = estate.estateDetail.DetailNumBedroom;
                        epEstateDetail.Timestamp = DateTime.Now;
                        epEstateDetail.IsDelete = false;
                    }
                    
                    
                   _context.SaveChanges();
                }

                return estate;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating estate: {ex.Message}");
                throw;
            }
        }

        public List<EstateImg> UpdateEstateImg(List<EstateImg> estateImgList)
        {
            foreach (var img in estateImgList)
            {
                if (img.ImgId == null || img.ImgId == 0)
                {
                    // New image
                    var newEntity = new EpEstateImg
                    {
                        EstateId = img.EstateId,
                        ImgUrl = img.ImgUrl,
                        IsDelete = false,
                        Timestamp = DateTime.Now
                    };
                    _context.EpEstateImgs.Add(newEntity);
             
                    img.ImgId = newEntity.ImgId;
                }
                else
                {
                    // Try to fetch
                    var existing = _context.EpEstateImgs
                                           .Find(img.ImgId);

                    if (existing != null)
                    {
                        // Update 
                        existing.EstateId = img.EstateId;
                        existing.ImgUrl = img.ImgUrl;
                        existing.IsDelete = false;
                        existing.Timestamp = DateTime.Now;
                    }
                    else
                    {
                        // new
                        var fallback = new EpEstateImg
                        {
                            EstateId = img.EstateId,
                            ImgUrl = img.ImgUrl,
                            IsDelete = false,
                            Timestamp = DateTime.Now
                        };
                        _context.EpEstateImgs.Add(fallback);

                        // Optionally update DTO with new key
                        img.ImgId = fallback.ImgId;
                    }
                }
            }

            _context.SaveChanges();
            return estateImgList;
        }

        public bool DeleteEstate(string estateId)
        {
            try
            {
                var epEstate = _context.EpEstates.Where(x => x.EstateId == estateId && x.IsDelete == false).FirstOrDefault();
                if (epEstate != null)
                {
                    epEstate.IsDelete = true;
                    epEstate.Timestamp = DateTime.Now;

                    var epEstateDetails = _context.EpEstateDetails.Where(x => x.EstateId == estateId && x.IsDelete == false).FirstOrDefault();
                    if (epEstateDetails != null)
                    {
                        epEstateDetails.IsDelete = true;
                        epEstateDetails.Timestamp = DateTime.Now;
                    }

                    var epEstateImgs = _context.EpEstateImgs.Where(x => x.EstateId == estateId && x.IsDelete == false).ToList();
                    foreach (var img in epEstateImgs)
                    {
                        img.IsDelete = true;
                        img.Timestamp = DateTime.Now;
                    }

                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error updating estate: {ex.Message}");
                throw;
            }
            return false;
        }

        public List<string> GetHomepageImgs()
        {
            //Add .AsNoTracking() for performance (if just reading data)
            var imageList = (from x in _context.EpHomepageImgs.AsNoTracking()
                             join y in _context.EpEstateImgs.AsNoTracking()
                             on x.ImageId equals y.ImgId
                             where !x.IsDelete && !y.IsDelete
                             select y.ImgUrl).ToList();


            return imageList;
        }

        public string GenerateEstateId()
        {
            string newId;
            var lastEstate = _context.EpEstates
                .OrderByDescending(e => e.EstateId)
                .FirstOrDefault();

            string yearMonthdate = DateTime.Today.ToString("yyyyMMdd"); 

            if (lastEstate == null || string.IsNullOrEmpty(lastEstate.EstateId))
            {
                newId = $"{yearMonthdate}0001";
            }
            else
            {
                string lastId = lastEstate.EstateId;

                // Check if the last ID is from the same year & month
                if (lastId.StartsWith(yearMonthdate))
                {
                    int lastNumber = int.Parse(lastId.Substring(6));
                    newId = $"{yearMonthdate}{(lastNumber + 1).ToString("D4")}";
                }
                else
                {
                    newId = $"{yearMonthdate}0001";
                }
            }

            return newId;
        }
    }
}
