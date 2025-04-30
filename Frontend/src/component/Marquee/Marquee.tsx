import { useEffect, useState } from 'react';

function Marquee({ imageList }: { imageList: string[] }) {
  const [currentIndex, setCurrentIndex] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentIndex(prevIndex => (prevIndex + 1) % imageList.length);
    }, 5000);

    return () => clearInterval(interval);
  }, [imageList.length]);

  const nextImage = () => {
    setCurrentIndex((currentIndex + 1) % imageList.length);
  };

  const prevImage = () => {
    setCurrentIndex((currentIndex - 1 + imageList.length) % imageList.length);
  };

  return (
    <div className="marquee_box relative w-[50vw] h-[50vh] overflow-hidden border">
      {/* back button */}
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        onClick={prevImage}
        viewBox="0 0 24 24"
        strokeWidth={1.5}
        stroke="currentColor"
        className="absolute top-1/2 -translate-y-1/2  left-1 w-6 h-6 z-30 bg-gray-300 text-white p-1 rounded cursor-pointer"
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          d="M6.75 15.75 3 12m0 0 3.75-3.75M3 12h18"
        />
      </svg>

      {imageList.map((image, index) => (
        <div
          key={index}
          className={`absolute top-0 left-0 w-full h-full transition-opacity duration-1000 ${
            index === currentIndex ? 'opacity-100' : 'opacity-0'
          }`}
        >
          <img src={image} className="w-full h-full object-cover" />
        </div>
      ))}

      {/* next button */}
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        strokeWidth={1.5}
        stroke="currentColor"
        onClick={nextImage}
        className="absolute top-1/2 -translate-y-1/2  right-1 w-6 h-6 z-30 bg-gray-300 text-white p-1 rounded cursor-pointer"
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          d="M17.25 8.25 21 12m0 0-3.75 3.75M21 12H3"
        />
      </svg>
    </div>
  );
}

export default Marquee;
