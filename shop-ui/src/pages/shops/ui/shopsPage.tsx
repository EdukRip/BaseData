export const ShopsPage = (lol : MyTestProps) => {
  return (
    <>
      <h1>Магазины Мегастрой</h1>
      <p>Список магазинов</p>
      <>{lol.msg}</>
    </>
  );
};

interface MyTestProps
{
  msg : string,
}