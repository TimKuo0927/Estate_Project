import { useEffect, useState } from "react";

function Marquee({ imageList }: { imageList: string[] }) {
    const [currentIndex, setCurrentIndex] = useState(0);

    useEffect(() => {
        const interval = setInterval(() => {
            setCurrentIndex((prevIndex) => (prevIndex + 1) % imageList.length);
        }, 5000);

        return () => clearInterval(interval);
    }, [imageList.length]);

    return (
        <div className="marquee_box relative w-[300px] h-[200px] overflow-hidden border">
            {imageList.map((image, index) => (
                <div
                    key={index}
                    className={`absolute top-0 left-0 w-full h-full transition-opacity duration-1000 ${
                        index === currentIndex ? "opacity-100" : "opacity-0"
                    }`}
                >
                    <img src={image} className="w-full h-full object-cover" />
                </div>
            ))}
        </div>
    );
}

export default Marquee;
