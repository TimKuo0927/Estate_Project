import Header from '../Header/Header';
import Footer from '../Footer/Footer';
import { Outlet } from 'react-router-dom';

function ClientLayout() {
  return (
    <>
      <div className="top-0 w-full">
        <Header />
      </div>
      <div className="grid grid-cols-10">
        <div className="col-start-1 col-end-3"></div>
        <main className="p-8 col-start-3 col-end-9">
          <Outlet />
        </main>
        <div className="col-start-8 col-end-10"></div>
      </div>

      <div className="bottom-0 w-full">
        <Footer />
      </div>
    </>
  );
}

export default ClientLayout;
