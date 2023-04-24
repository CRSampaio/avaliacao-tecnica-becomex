import { api } from "../config/fetchAPI.js";

const GetStatus = async () => {
    return await api.get("/")
}

export default GetStatus