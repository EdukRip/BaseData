import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";
import { Button } from "antd";
import { EyeOutlined, PlusOutlined, EditOutlined } from "@ant-design/icons";



export const GoodsPage = () => {
  const navigation = useNavigate();
  return (
    <>
      <h1>Товары</h1>
      <p>Список товаров</p>

      <Button icon={<EyeOutlined />} onClick={() => navigation(Routings.good.view.toNavigate('1'))}>Просмотр</Button>
      <Button icon={<PlusOutlined />} onClick={() => navigation(Routings.good.create.toNavigate())}>Создать</Button>
      <Button icon={<EditOutlined />} onClick={() => navigation(Routings.good.edit.toNavigate('1'))}>Редактировать</Button>
    </>
  );
};  