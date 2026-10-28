import './App.css';
// import { ClientsPage } from './pages/clients/ui/clientsPage';
// import { GoodsPage } from './pages/goods/ui/goodsPage';
// import { ShopsPage } from './pages/shops/ui/shopsPage';
import { NavLink, Outlet } from 'react-router';
import { Layout, Menu } from 'antd';

const menuItems = [
  {
    key: "shops",
    label: <NavLink to="/shops">Магазины</NavLink>,
  },
  {
    key: "clients",
    label: <NavLink to="/clients">Клиенты</NavLink>,
  },
  {
    key: "goods",
    label: <NavLink to="/goods">Товары</NavLink>,
  },
];

const { Header, Content, Footer } = Layout;
const App = () => {
  return <Layout style={{ height: "100%", width: "100" }}>
    <Header><Menu items={menuItems} theme="dark" mode="horizontal"></Menu></Header>
    <Content><Outlet /></Content>
    <Footer style={{ textAlign: "center" }}>Система мониторинга shop-ui</Footer>
  </Layout>
  // return (
  //   <div className="content">
  //     App
  //     <NavLink to="/clients">Клиенты</NavLink>
  //     <NavLink to="/shops">Магазины</NavLink>
  //     <NavLink to="/goods">Товары</NavLink>
  //     <Outlet />

  //     {/* <NavLink to="/" end>Домашняя страница</NavLink> */}
  //   </div>
  // );
};

export default App;
