import { Button } from "antd";
import { useNavigate } from "react-router"
import { Routings } from "../../../shared/routing/routings";


export const ClientsCreatePage = () =>
{
    const navigation = useNavigate();
    return (
        <>
            <p>Создание</p>
            <Button onClick={() => navigation(Routings.client.list.toNavigate())}>Возврат</Button>
        </>
    )
}