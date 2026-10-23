import { NavLink } from "react-router";

export const GoodsPage = () => {
  return (
    <>
      <h1>Товары</h1>
      <p>Список товаров</p>
      
      <NavLink to = "/" end>Домашняя страница</NavLink>
    </>
  );
};  