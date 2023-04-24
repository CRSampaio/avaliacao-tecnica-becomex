import { api } from "../config/fetchAPI.js";


const CabecaService = () => {

    const getStatus = async () => {
        return await apiGetStatus()
    }
    const setAcao = async (acao) => {
        await apiAcao(acao);
    }
    return { setAcao, getStatus };
}
const apiAcao = async (acao) => {
    await api.post("/Cabeca" + acao, {})
}
const apiGetStatus = async () => {
    return await api.get("/Cabeca/Status")
}
export default CabecaService;