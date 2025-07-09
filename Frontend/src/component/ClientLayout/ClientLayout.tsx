import Header from '../Header/Header';
import Footer from '../Footer/Footer';
import { Outlet } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { userData } from '../../../model/User';

interface ClientLayoutProps {
  isLogin: boolean;
  userData: userData;
}

function ClientLayout({ isLogin, userData }: ClientLayoutProps) {
  const navigate = useNavigate();

  const renderHomePage = () => {
    navigate('/');
  };

  const renderSignPage = () => {
    navigate('/signIn');
  };

  return (
    <>
      <div className="top-0 w-full">
        <Header
          HomeOnClick={renderHomePage}
          SignOnClick={renderSignPage}
          isLogin={isLogin}
          userData={userData}
        />
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
