import PulsoService from "./services/pulsoService.js";
import CotoveloService from "./services/cotoveloService.js";
import CabecaService from "./services/cabecaService.js";
import GetStatus from "./services/statusService.js";
import { AcaoCotoveloBracoRoute, LadoBracoRoute, RotacionarPulsoBracoRoute } from "./config/routes/bracoRoute.js";
window.onload = () => {
    load()
}

const load = async () => {

    const robo = await GetStatus();

    setupRobo(robo)

    const braco = document.getElementById("braco")

    const bracoEsquerdoElement = braco.querySelector("#esquerdo")
    configPulso(bracoEsquerdoElement, LadoBracoRoute.Esquerdo);
    configCotovelo(bracoEsquerdoElement, LadoBracoRoute.Esquerdo);

    const bracoDireitoElement = braco.querySelector("#direito")
    configPulso(bracoDireitoElement, LadoBracoRoute.Direito);
    configCotovelo(bracoDireitoElement, LadoBracoRoute.Direito);


    configCabeca(document.getElementById("cabeca"))


}

const setupRobo = (robo) => {

    const braco = document.getElementById("braco")

    const bracoEsquerdoElement = braco.querySelector("#esquerdo")    
    bracoEsquerdoElement.querySelector(".pulso .status").innerHTML = robo.bracoEsquerdo.pulso.estadoPulso
    bracoEsquerdoElement.querySelector(".cotovelo .status").innerHTML = robo.bracoEsquerdo.cotovelo.estadoCotovelo

    const bracoDireitoElement = braco.querySelector("#direito")
    const pulsoElement = bracoDireitoElement.querySelector(".pulso .status").innerHTML = robo.bracoDireito.pulso.estadoPulso
    bracoDireitoElement.querySelector(".cotovelo .status").innerHTML = robo.bracoDireito.cotovelo.estadoCotovelo

    const cabeca = document.getElementById("cabeca")
    cabeca.querySelector(".inclinacao .status").innerHTML = robo.cabeca.estadoInclinacao
    cabeca.querySelector(".rotacao .status").innerHTML = robo.cabeca.estadoRotacao


}

const configPulso = (bracoElement, lado) => {

    const pulsoElement = bracoElement.querySelector(".pulso");
    const pulsoService = PulsoService(lado)

    const btnPulsoNegativo = pulsoElement?.querySelector(".btnRotacionarNegativo")
    btnPulsoNegativo?.addEventListener('click', async () => {

        await pulsoService.setRotacionar(RotacionarPulsoBracoRoute.Negativo)
        const status = await pulsoService.getStatus()
        pulsoElement.querySelector(".status").innerHTML = status.estadoPulso;
    })
    const btnPulsoPositivo = pulsoElement?.querySelector(".btnRotacionarPositivo")
    btnPulsoPositivo?.addEventListener('click', async () => {
        await pulsoService.setRotacionar(RotacionarPulsoBracoRoute.Positivo)
        const status = await pulsoService.getStatus()
        pulsoElement.querySelector(".status").innerHTML = status.estadoPulso;
    })
}

const configCotovelo = (bracoElement, lado) => {
    const cotoveloElement = bracoElement.querySelector(".cotovelo");
    const cotoveloService = CotoveloService(lado)

    const btnCotoveloRelaxar = cotoveloElement?.querySelector(".btnRelaxar")
    btnCotoveloRelaxar?.addEventListener('click', async () => {
        await cotoveloService.setAcao(AcaoCotoveloBracoRoute.Relaxar)

        const status = await cotoveloService.getStatus()
        cotoveloElement.querySelector(".status").innerHTML = status.estadoCotovelo;
    })
    const btnCotoveloContrair = cotoveloElement?.querySelector(".btnContrair")
    btnCotoveloContrair?.addEventListener('click', async () => {
        await cotoveloService.setAcao(AcaoCotoveloBracoRoute.Contrair)
        const status = await cotoveloService.getStatus()
        cotoveloElement.querySelector(".status").innerHTML = status.estadoCotovelo;
    })
}


const configCabeca = (element) => {
    const inclinacaoElement = element.querySelector(".inclinacao");
    const inclinacaoService = CabecaService()


    const btnAbaixar = inclinacaoElement?.querySelector(".btnAbaixar")
    btnAbaixar?.addEventListener('click', async () => {
        await inclinacaoService.setAcao("/Abaixar")

        const status = await inclinacaoService.getStatus()
        inclinacaoElement.querySelector(".status").innerHTML = status.estadoInclinacao;
    })

    const btnSubir = inclinacaoElement?.querySelector(".btnSubir")
    btnSubir?.addEventListener('click', async () => {
        await inclinacaoService.setAcao("/Subir")

        const status = await inclinacaoService.getStatus()
        inclinacaoElement.querySelector(".status").innerHTML = status.estadoInclinacao;
    })



    const rotacaoElement = element.querySelector(".rotacao");
    const rotacaoService = CabecaService()

    const btnRotacionarNegativo = rotacaoElement?.querySelector(".btnRotacionarNegativo")
    btnRotacionarNegativo?.addEventListener('click', async () => {
        await rotacaoService.setAcao("/RotacionarNegativo")

        const status = await rotacaoService.getStatus()
        rotacaoElement.querySelector(".status").innerHTML = status.estadoRotacao;
    })

    const btnRotacionarPositivo = rotacaoElement?.querySelector(".btnRotacionarPositivo")
    btnRotacionarPositivo?.addEventListener('click', async () => {
        await rotacaoService.setAcao("/RotacionarPositivo")

        const status = await rotacaoService.getStatus()
        rotacaoElement.querySelector(".status").innerHTML = status.estadoRotacao;
    })

}

