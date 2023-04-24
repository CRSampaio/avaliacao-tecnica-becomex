import { api } from "../config/fetchAPI.js";

const PulsoService = (lado) => {
    const getStatus = async () => {
        return await apiGetStatus(lado)
    }
    const setRotacionar = async (direcao) => {
        await apiRotacionar(lado, direcao);
    }
    return { setRotacionar,getStatus };
}

const apiRotacionar = async (lado, direcao) => {
    const a = await api.post("/Braco" + lado + "/Pulso" + direcao, {})
}
const apiGetStatus = async (lado,) => {
    return await api.get("/Braco" + lado + "/Pulso/Status")
}
export default PulsoService;