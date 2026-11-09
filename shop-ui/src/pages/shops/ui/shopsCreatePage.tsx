import { Button } from "antd";
import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";

export const ShopsCreatePage = () =>
{
    const navigation = useNavigate();
    return (
        <>
            <p>Создание</p>

            <Button onClick={() => navigation(Routings.shop.list.toNavigate())}>Возврат</Button>
        </> 
    )
};