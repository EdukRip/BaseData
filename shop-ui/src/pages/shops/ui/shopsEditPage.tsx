import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";
import { Button } from "antd";

export const ShopsEditPage = () =>
{
    const navigation = useNavigate()
    return (
        <>
            <p>Редактирование</p>

            <Button onClick={() => navigation(Routings.shop.list.toNavigate())}>Возврат</Button>
        </>
    )
};