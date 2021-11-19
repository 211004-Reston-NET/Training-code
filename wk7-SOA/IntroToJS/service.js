//AJAX demo
function GetPokemon() {
    //Object that will talk to an api
    let xhr = new XMLHttpRequest();

    let pokemon = {};

    let pokemonName = document.querySelector("#pokemonName").value;

    /*
        onreadystatechanage describes the current state of your http request
        0 - uninitialized
        1 - loading (server connection established)
        2 - loaded (request received and response is currently being made)
        3 - interactive (response is being processed by your browser)
        4 - complete
    */

    xhr.onreadystatechange = function ()
    {
        //if condition checks if the response is completed and successful
        if (this.readyState == 4 && this.status > 199 && this.status < 300) {
            
            //api gives json so we parse it into the pokemon object that json understands
            pokemon = JSON.parse(xhr.responseText);

            //this will select our image element with the id of pikachuImage and change the src attribute to whatever we found on the api
            document.querySelector("#pokemonImage").setAttribute("src", pokemon.sprites.front_default);

            //Looks at the div that has result id and specifically selects every caption inside of that div
            //the for each method gets each element and removes them
            document.querySelectorAll("#result caption").forEach((element) => element.remove());

            //This creates the caption element but we haven't attached it to the dom yet (so it won't be visible)
            let caption = document.createElement("caption");

            //Sets the innerHTML of the caption
            //<caption> innerHtml </caption>
            caption.innerHTML = pokemon.forms[0].name;

            //Append the caption element we created inside of the div element as its child
            document.querySelector("#result").appendChild(caption);
        }
    }

    //how AJAX/XMLHttpRequest sends an http request to the endpoint
    //First param is the http verb, second param is the endpoint, third param if you want it in asynchrounous operation
    xhr.open("GET", `https://pokeapi.co/api/v2/pokemon/${pokemonName}`,true);

    //Sends the request
    xhr.send();
}

//Fetch Demo
function GetPokemonFetch() {
    let pokemonName = document.querySelector("#pokemonName").value;

    fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonName}`)
        .then(result => result.json())
        .then(pokemon => {
            document.querySelector("#pokemonImageFetch").setAttribute("src", pokemon.sprites.front_default);
        })
}