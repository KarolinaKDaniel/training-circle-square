import '@riotjs/hot-reload'
import { mount, register, install } from 'riot'
import Hub from './hub'
import GameBoard from './components/game-board/game-board.riot'
import OxField from './components/ox-field/ox-field.riot'
import TextDisplay from './components/text-display/text-display.riot'
import NewGameButton from './components/new-game-button/new-game-button.riot'

var appState = {
    oxFields: {}
    };

// SignalR
var hub = new Hub("http://localhost:5000/xohub");

// ----------------------------------
// SignalR calls from backend go here

hub.connection.on("CurrentFieldValue", (fieldId, value) => {
    appState.oxFields[fieldId].update({value})
})

hub.connection.on("FieldIsFilled", (value) => {
    appState.textDisplay.update({value})
})

// SignalR calls from backend go here
// ----------------------------------

// RiotJs
install(function(component) {
    component.appState = appState;
    component.hub = hub.connection;
})

// -----------------------------------------------
// RiotJs component registration happens here here

register('ox-field', OxField)
register('game-board', GameBoard)
register('text-display', TextDisplay)
register('new-game-button', NewGameButton)

// RiotJs component registration happens here here
// -----------------------------------------------

async function StartApp() {
    await hub.start()
    mount('game-board')
}

StartApp()
