import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";
import { Button } from "antd";

export const GoodsViewPage = () =>
{
    const navigation = useNavigate()
    return (
        <>
            <p>Просмотр</p>

            <Button onClick={() => navigation(Routings.good.list.toNavigate())}>Возврат</Button>
        </>
    )
};