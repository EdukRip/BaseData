import { useNavigate } from "react-router";
import { Routings } from "../../../shared/routing/routings";
import { Button } from "antd";

export const ClientsViewPage = () =>
{
    const navigation = useNavigate()
    return (
        <>
            <p>Просмотр</p>

            <Button onClick={() => navigation(Routings.client.list.toNavigate())}>Возврат</Button>
        </>
    )
};