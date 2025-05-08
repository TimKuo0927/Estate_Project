import Header from '../Header/Header';
import Footer from '../Footer/Footer';
import { Outlet } from 'react-router-dom';

function ClientLayout() {
  return (
    <>
      <div className="absolute top-0">
        <Header />
      </div>
      <main className="p-4">
        <Outlet />
      </main>
      <div className="absolute bottom-0">
        <Footer />
      </div>
    </>
  );
}

export default ClientLayout;
