import { Button } from "antd";
import { useNavigate } from "react-router"
import { Routings } from "../../../shared/routing/routings";

export const ClientsEditPage = () =>
{
    const navigation = useNavigate();
    return (
        <>
            <p>Редактирование</p>
            
            <Button onClick={() => navigation(Routings.client.list.toNavigate())}></Button>
        </>
    )
}