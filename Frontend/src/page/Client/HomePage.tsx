import Button from '../../component/Button/Button';
import Marquee from '../../component/Marquee/Marquee';

import backendConnector from '../../api';
import { EstateImage } from '../../../model/estate/EstateImage';

import { useEffect, useState } from 'react';

function HomePage() {
  const [loading, setLoading] = useState(true);
  const [images, setImages] = useState<EstateImage[]>([]);
  // const imageList: string[] = [
  //     'https://images.unsplash.com/photo-1744600511717-54db78d29098?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
  //     'https://images.unsplash.com/photo-1745750747233-c09276a878b3?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
  //     'https://images.unsplash.com/photo-1745761412274-5303bc3f2e45?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
  //   ];

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
      <div className="m-3 text-left p-3">
        <strong className="text-4xl mb-2">Your Dream Home Awaits</strong>
        <div className="text-gray-400 mb-4">
          Explore listings, compare prices, and move in faster.
        </div>

        <Button label="Get Started" variant="secondary" />
      </div>

      <div className="flex flex-col items-center justify-center">
        <Marquee imageList={images.map(x => x.imgUrl)} />
        {/* <Marquee imageList={imageList} /> */}
      </div>
    </>
  );
}

export default HomePage;
