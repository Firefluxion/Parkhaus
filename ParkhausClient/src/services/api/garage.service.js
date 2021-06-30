import axios from "axios";

export var GarageService = {
    test,
};

function test() {
    console.log("test")
    axios.post("https://localhost:44341/weatherforecast/Test", 7);
    console.log("test done")
}

