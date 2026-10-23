import './App.css';
// import { ClientsPage } from './pages/clients/ui/clientsPage';
// import { GoodsPage } from './pages/goods/ui/goodsPage';
// import { ShopsPage } from './pages/shops/ui/shopsPage';
import { NavLink, Outlet } from 'react-router';

const App = () => {
  return (
    <div className = "content">
      App
      <NavLink to = "/clients">Клиенты</NavLink>
      <NavLink to = "/shops">Магазины</NavLink>
      <NavLink to = "/goods">Товары</NavLink>
      <Outlet/>
    </div>
  );
};

export default App;
