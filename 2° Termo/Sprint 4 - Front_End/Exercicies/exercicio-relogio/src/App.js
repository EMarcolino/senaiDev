import React from "react";
import "./App.css";

// Define uma função DataFormatada que retorna o subtítulo com o valor da data formatada
function DataFormatada(props) {
	return <h2> Horário Atual: {props.date.toLocaleTimeString()} </h2>;
}

// Define a class Clock que será chamada na renderização dentro da App
class Clock extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			// Define o estado date pegando a data atual
			date: new Date(),
		};
	}

	// Ciclo de vida que ocorre quando Clock é inserida no DOM
	// Através do setInterval, o relógio é criado (com um timerID atrelado)
	// Chama a função thick a cada 1000ms (1s)
	componentDidMount() {
		this.timerID = setInterval(() => {
			this.thick();
		}, 1000);

		this.id = this.timerID;

		// Exibe no console o ID de cada relógio
		console.log("Eu sou o relógio " + this.timerID);
	}

	// Ciclo de vida que ocorre quando o componento é removido do DOM
	// Quando isso ocorre, a função clearInterval limpa o relógio criado pelo setInterval
	componentWillUnmount() {
		clearInterval(this.timerID);
	}

	// Define no state date a data atual a cada vez que é chamada
	thick() {
		this.setState({
			date: new Date(),
		});
	}

	StopWatch = () => {
		clearInterval(this.id);
		console.clear();
		console.log(`Relógio ${this.id} pausado.`);
	};

	ResumeWatch = () => {
		this.id = setInterval(() => {
			this.thick();
		}, 1000);

		console.clear();
		console.log("Relógio retomado.");
		console.log(`Agora sou o relógio ${this.id}.`);
	};

	// Renderiza na tela o título e a função DataFormada, passando date com o valor atual do state
	render() {
		return (
			<div>
				<h1> Relógio </h1>

				<DataFormatada date={this.state.date} />

				<button
					className="btn btn-stop"
					type="button"
					onClick={this.StopWatch}
				>
					Pausar
				</button>

				<button
					className="btn btn-resume"
					type="button"
					onClick={this.ResumeWatch}
				>
					Retomar
				</button>
			</div>
		);
	}
}

function App() {
	return (
		<div className="App">
			<header className="App-header">
				{/* Faz a chamada de dois relógios para mostrar a independência destes */}
				<Clock />
				<Clock />
			</header>
		</div>
	);
}

export default App;