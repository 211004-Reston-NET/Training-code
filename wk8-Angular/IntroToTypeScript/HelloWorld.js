//=================== Variables ===================
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
console.log("==== Variable ====");
//Anything you assign to a variable you just created will have that datatype
//In this case, s1 will only hold strings
var s1 = "hello";
var s2; //C# equivalent, string s2;
s2 = "world";
//console.log(s1);
//s1 = 5; Note: TS will give a compiler error but will still run in JS perfectly fine since it is not type safety 
//console.log(s1);
console.log("".concat(s1, " ").concat(s2));
//ANY - the default type of a declared variable if not implicity or explicity given a datatype
var a1;
a1 = "hello";
a1 = 5;
a1 = null;
a1 = false;
//Number
var n1;
n1 = 10;
//You can supply multiple types to a single variable
var m1;
m1 = "string";
m1 = 10;
m1 = true;
//DO NOT use void or never as datatypes in a variable, void is for function return types
//Never is used fo error handling
//NULL and UNDEFINED
var nul1; //undefined if you didn't set a value to something
var nul2 = null; //null is the meaning of lack of value
console.log(typeof (nul1));
console.log(typeof (nul2));
//Array
var arry1;
arry1 = ["string", true, 10];
arry1.push(null); //Adds an element to your array
console.log(arry1);
var arry2;
arry2 = ["string", 10, 5, 2];
// arry2.push(true);
var arry3;
arry3 = "string";
arry3 = [10, 6, 3];
// arry3 = [10, "string"]; Cannot be both
//TUPLE - It is an array but a fixed position of datatypes
var tup1;
tup1 = [10, "string", "string", true];
// tup1 = ["string", 10, "string", false];
console.log(tup1);
tup1.push(6, "string", "string", false);
console.log(tup1);
//ENUM - enumeration, specified set of constants. Mostly used to be easier to read your code
var Engine;
(function (Engine) {
    Engine[Engine["Off"] = 0] = "Off";
    Engine[Engine["On"] = 1] = "On";
    Engine[Engine["Accel"] = 2] = "Accel";
})(Engine || (Engine = {}));
var engineState = 0;
if (engineState == Engine.Off) {
    console.log("Engine is Off");
}
if (engineState == 0) {
    console.log("Engine is Off");
}
//===================== Functions ===================== 
console.log("==== Function ====");
function Print(para1, para2) {
    console.log("".concat(para1, " ").concat(para2));
}
Print("Hello", "World");
function Print2(para1, para2) {
    return "".concat(para1, " ").concat(para2);
}
console.log(Print2("Hello", "World"));
//===================== Classes and Objects ===================== 
console.log("==== Classes and Objects ====");
var Pokemon = /** @class */ (function () {
    function Pokemon(p_name, p_move, p_health, p_attack) {
        if (p_name === void 0) { p_name = ""; }
        if (p_move === void 0) { p_move = ""; }
        if (p_health === void 0) { p_health = 0; }
        if (p_attack === void 0) { p_attack = 0; }
        this.name = p_name;
        this.move = p_move;
        this.health = p_health;
        this.attack = p_attack;
    }
    //We can do method overloading by using optional or default parameters
    Pokemon.prototype.catchPhrase = function (p_say) {
        if (p_say === void 0) { p_say = ""; }
        console.log("Gotta catch em all");
        console.log(p_say);
    };
    return Pokemon;
}());
var poke;
poke = new Pokemon("Pikachu", "thunderbolt", 100, 60);
poke.catchPhrase();
poke.catchPhrase("Pikachu nooooooo");
var Pikachu = /** @class */ (function (_super) {
    __extends(Pikachu, _super);
    function Pikachu() {
        return _super.call(this) || this;
    }
    //Method overriding
    Pikachu.prototype.catchPhrase = function (p_say) {
        if (p_say === void 0) { p_say = ""; }
        console.log("".concat(p_say, " That's a catch phase!"));
    };
    return Pikachu;
}(Pokemon));
var poke2 = new Pikachu();
poke2.catchPhrase("Pika PIIII");
var Zapdos = /** @class */ (function () {
    function Zapdos() {
    }
    Zapdos.prototype.thunderBolt = function () {
    };
    return Zapdos;
}());
