import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";
import { Button } from "antd";

export const ShopsViewPage = () =>
{
    const navigation = useNavigate()
    return (
        <>
            <p>Просмотр</p>

            <Button onClick={() => navigation(Routings.shop.list.toNavigate())}>Возврат</Button>
        </>
    )
};