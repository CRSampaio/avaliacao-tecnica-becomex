export const api = {
    get: async (rota) => await fetch("http://localhost:5000/Robo" + rota).then(x => x.json()),
    post: async (rota, body) => await fetch("http://localhost:5000/Robo" + rota, { method: 'POST', body: JSON.stringify(body) })
        .then(async x => {
            if (x.status == 500) {
                const a = await x.json()
                alert(a.Message)
            }
        }).catch(x=>alert("Não foi possivel"))
}