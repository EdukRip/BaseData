import './App.css';
import { ClientsPage } from './pages/clients/ui/clientsPage';
import { GoodsPage } from './pages/goods/ui/goodsPage';
import { ShopsPage } from './pages/shops/ui/shopsPage';

const App = () => {
  return (
    <>
      <ShopsPage />
      <GoodsPage />
      <ClientsPage />
    </>
  );
};

export default App;
