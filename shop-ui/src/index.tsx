import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { ClientsPage } from './pages/clients/ui/clientsPage';
import { GoodsPage } from './pages/goods/ui/goodsPage';
import { ShopsPage } from './pages/shops/ui/shopsPage';
import { createBrowserRouter } from 'react-router';
import { RouterProvider } from 'react-router/dom';
import { Routings } from './shared/routing/routings';
import App from './App';

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
        path: Routings.good.list.path,
        // path: <Routings.good.list.toNavigate()></Routings>,
        element: <GoodsPage></GoodsPage>, // Лучше сделать в одном стиле, но я проверял, что так можно
      },
      {
        path: Routings.shop.list.path,
        element: <ShopsPage msg="" />,
      }
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
