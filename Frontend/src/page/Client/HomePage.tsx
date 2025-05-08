import Button from '../../component/Button/Button';
import Marquee from '../../component/Marquee/Marquee';

import backendConnector from '../../api';
import { EstateImage } from '../../../model/estate/EstateImage';

import { useEffect, useState } from 'react';

function HomePage() {
  const [loading, setLoading] = useState(true);
  const [images, setImages] = useState<EstateImage[]>([]);

  useEffect(() => {
    const fetchImgs = async () => {
      try {
        const imgs = await backendConnector.estate.getHomepageImgs();
        setImages(imgs);
      } catch (error) {
        console.error('Failed to fetch homepage images', error);
      } finally {
        setLoading(false);
      }
    };

    fetchImgs();
  }, []);

  if (loading) {
    return <div>Loading</div>;
  }

  return (
    <>
      <strong className="text-4xl">Your Dream Home Awaits</strong>
      <div className="text-gray-400">Explore listings, compare prices, and move in faster.</div>
      <Button label="Get Started" variant="secondary" />
      <Marquee imageList={images.map(x => x.imgUrl)} />
    </>
  );
}

export default HomePage;
