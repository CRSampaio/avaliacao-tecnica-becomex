import { api } from "../config/fetchAPI.js";

const CotoveloService = (lado) => {

    const getStatus = async () => {
        return await apiGetStatus(lado)
    }
    const setAcao = async (acao) => {
        await apiAcao(lado, acao);
    }
    return { setAcao, getStatus };
}

const apiAcao = async (lado, acao) => {
    await api.post("/Braco" + lado + "/Cotovelo" + acao, {})
}
const apiGetStatus = async (lado,) => {
    return await api.get("/Braco" + lado + "/Cotovelo/Status")
}

export default CotoveloService;