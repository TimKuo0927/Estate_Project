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
                                  estateDetail = detail,
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
                    var epEstate = new EpEstate
                    {
                        EstateId = GenerateEstateId(),
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
                        var epDetail = estate.estateDetail;
                        epDetail.EstateId = epEstate.EstateId;
                        _context.EpEstateDetails.Add(epDetail);
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
                        epEstateDetail = estate.estateDetail;
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
                                           .FirstOrDefault(x => x.ImgId == img.ImgId);

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
