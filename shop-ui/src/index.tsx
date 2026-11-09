import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { ClientsPage } from './pages/clients/ui/clientsPage';
import { ClientsViewPage } from './pages/clients/ui/clientsViewPage';
import { ClientsCreatePage } from './pages/clients/ui/clientsCreatePage';
import { ClientsEditPage } from './pages/clients/ui/clientsEditPage';
import { GoodsPage } from './pages/goods/ui/goodsPage';
import { GoodsViewPage } from './pages/goods/ui/goodsViewPage';
import { GoodsCreatePage } from './pages/goods/ui/goodsCreatePage';
import { GoodsEditPage } from './pages/goods/ui/goodsEditPage';
import { ShopsPage } from './pages/shops/ui/shopsPage';
import { createBrowserRouter } from 'react-router';
import { RouterProvider } from 'react-router/dom';
import { Routings } from './shared/routing/routings';
import App from './App';
import { ShopsViewPage } from './pages/shops/ui/shopsViewPage';
import { ShopsCreatePage } from './pages/shops/ui/shopsCreatePage';
import { ShopsEditPage } from './pages/shops/ui/shopsEditPage';


const router = createBrowserRouter([
  {
    path: '/', // маршрут '/'
    element: <App />, // Компонент 'App'
    children: [
      {
        path: Routings.client.list.path,
        element: <ClientsPage />,
      },
      {
        path: Routings.client.view.path,
        element: <ClientsViewPage />,
      },
      {
        path: Routings.client.create.path,
        element: <ClientsCreatePage />,
      },
      {
        path: Routings.client.edit.path,
        element: <ClientsEditPage />,
      },
      {
        path: Routings.good.list.path,
        // path: <Routings.good.list.toNavigate()></Routings>,
        element: <GoodsPage></GoodsPage>, // Лучше сделать в одном стиле, но я проверял, что так можно
      },
      {
        path: Routings.good.view.path,
        element: <GoodsViewPage></GoodsViewPage>,
      },
      {
        path: Routings.good.create.path,
        element: <GoodsCreatePage></GoodsCreatePage>,
      },
      {
        path: Routings.good.edit.path,
        element: <GoodsEditPage></GoodsEditPage>,
      },
      {
        path: Routings.shop.list.path,
        element: <ShopsPage msg="" />,
      },
      {
        path: Routings.shop.view.path,
        element: <ShopsViewPage/>,
      },
      {
        path: Routings.shop.create.path,
        element: <ShopsCreatePage/>,
      },
      {
        path: Routings.shop.edit.path,
        element: <ShopsEditPage/>,
      },
    ]
  },
]);

const rootEl = document.getElementById('root');
if (rootEl) {
  const root = createRoot(rootEl);
  root.render(
    <StrictMode>
      <RouterProvider router={router} />
    </StrictMode>,
  );
}
