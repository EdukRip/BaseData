import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";
import { Button } from "antd";

export const GoodsEditPage = () =>
{
    const navigation = useNavigate()
    return (
        <>
            <p>Редактирование</p>

            <Button onClick={() => navigation(Routings.good.list.toNavigate())}>Возврат</Button>
        </>
    )
};