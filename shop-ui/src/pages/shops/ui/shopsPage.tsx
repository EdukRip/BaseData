import { NavLink } from "react-router";

export const ShopsPage = (lol : MyTestProps) => {
  return (
    <>
      <h1>Магазины Мегастрой</h1>
      <p>Список магазинов</p>
      <>{lol.msg}</>

      <NavLink to = "/" end>Домашняя страница</NavLink>
    </>
  );
};

interface MyTestProps
{
  msg : string,
}