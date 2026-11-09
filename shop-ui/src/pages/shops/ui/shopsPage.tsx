import { EditOutlined, EyeOutlined, PlusOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";

export const ShopsPage = (lol : MyTestProps) => {
  const navigation = useNavigate();
  return (
    <>
      <h1>Магазины Мегастрой</h1>
      <p>Список магазинов</p>
      <>{lol.msg}</>

      <Button icon={<EyeOutlined />} onClick={() => navigation(Routings.client.view.toNavigate('1'))}>Просмотр</Button>
      <Button icon={<PlusOutlined />} onClick={() => navigation(Routings.client.create.toNavigate())}>Создать</Button>
      <Button icon={<EditOutlined />} onClick={() => navigation(Routings.client.edit.toNavigate('1'))}>Редактировать</Button>
    </>
  );
};

interface MyTestProps
{
  msg : string,
}