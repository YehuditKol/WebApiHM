
let basicUrl='https://localhost:7170/api/Pizza/';

function getAllPizzas() {
    fetch(`${basicUrl}`)
    .then((res) => res.json()) 
    .then((data) =>  fillPizzaList(data)) 

    .catch(err=>{console.log(err)})
}
function fillPizzaList(pizzaList) {
    
    var tbody = document.getElementById('pizzatbody');
    var tb = document.getElementById("tb");
    // let thead=tb.createTHead();
    // tb.append(thead);
    // let tr=thead.insertRow();
    // let th1 = document.createElement("th");
    // let th2 = document.createElement("th");
    // th1.innerHTML="Name";
    // th2.innerHTML="IsGluten";
    // tr.append(th1);
    // tr.append(th2);
    // thead.append(tr);
    pizzaList.forEach(pizza => {
        var tr=tb.insertRow();
        var td3=tr.insertCell();
        var td=tr.insertCell();
        var td2=tr.insertCell();
        td3.append(`${pizza.id}`);
        td.append(`${pizza.name}`);
        td2.append(`${pizza.gluten}`)
        td.style.border = '1px solid black';
        td2.style.border = '1px solid black';
        td3.style.border = '1px solid black';
        tr.append(td3);
        tr.append(td);
        tr.append(td2);
        tbody.append(tr);
      
       
    });
    tb.setAttribute("border", "2");
}

function getPizzaById() {
    fetch(`${basicUrl}`)
    .then((res) => res.json()) 
    .then((data) =>  fillPizzaList(data)) 

    .catch(err=>{console.log(err)})
}

const name1=document.getElementById("name");
const id=document.getElementById("id");
const gluten=document.getElementById("gluten");
function post(){
    name1.style.display="block";
    id.style.display="block";
    gluten.style.display="block";
    document.getElementById("send").style.display="block";
}
function sendPost(){
    const namev=name1.value.trim();
    const idv=id.value.trim();
    const glutenv = gluten.value.trim();
    const token = sessionStorage.getItem("token");
    const myHeaders = new Headers();
    myHeaders.append("Authorization","Bearer " + token);
    myHeaders.append("Content-Type", "application/json");

    const json = `{\"name\": \" ${namev}\", \"gluten\": \ ${glutenv}\,\"id\": \ ${idv}\}`;
    const requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: json,
        redirect: "follow",
    };
    fetch(`${basicUrl}`,requestOptions)
    .then((response) => response.text())
    .then((result)=>{
        if(result.includes("400")){
            alert("faild to add!!")
        }
        else{
            alert("wowwwwwwwwwwwwwwwwwwwwwwww");
        }
    })
    .catch(err=>{console.log(err)})
}
const idGet=document.getElementById("idForGet");

function getById(){
    idGet.style.display="block";
    let buttonExecute=document.getElementById("execute");
    buttonExecute.style.display="block";
}
function executeForGetById(){
    let idValue=idGet.value.trim();
    fetch(`${basicUrl}${idValue}`)
    .then((res) => res.json()) 
    .then((data) => console.log(data)) 
    .catch(err=>{console.log(err)})
}
const executeDelete=document.getElementById("idDelete");
function deletePizza()
{

    executeDelete.style.display="block";
    let buttonExecute=document.getElementById("executeD");
    buttonExecute.style.display="block";
}
function fexecuteDelete()
{
    let idValue = idDelete.value.trim();
    const token = sessionStorage.getItem("token");
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + token);
    myHeaders.append("Content-Type", "application/json");
 
    //let id = `${idValue}`;
    var requestOptions = {
        method: "DELETE",
        headers: myHeaders,
        redirect: "follow",
    };

    fetch(`${basicUrl}${idValue}`,requestOptions)
    .then((res) => res.text()) 
    .then((data) => console.log(data)) 
    .catch(err=>{console.log(err)})
}
function putPizza(){
    const input = document.createElement("input");
    const input1 = document.createElement("input");
    const input2 = document.createElement("input");
    const input3 = document.createElement("input");
    // Set the ID and attributes
    input.id = "myInput";
    input.setAttribute("type", "text");
    input.setAttribute("placeholder", "Enter pizza id-to change");
    document.body.append(input);
    input1.id = "myId";
    input1.setAttribute("type", "number");
    input1.setAttribute("placeholder", "Enter pizza id");
    document.body.append(input1);
    input2.id = "myName";
    input2.setAttribute("type", "text");
    input2.setAttribute("placeholder", "Enter pizza name");
    document.body.append(input2);
    input3.id = "myGluten";
    input3.setAttribute("type", "text");
    input3.setAttribute("placeholder", "Enter pizza gluten");
    document.body.append(input3);
    var button = document.createElement("button");

// Set button attributes and properties
button.innerHTML = "Click Me"; // Button text
button.id = "myButton"; // ID attribute
button.onclick=sendPutPizza;
// Append the button to the document body or any other desired location
document.body.appendChild(button);
}
function sendPutPizza(){
    const id=document.getElementById("myInput").value.trim();
    const namePizza=document.getElementById("myName").value.trim();
    const idPizza=document.getElementById("myId").value.trim();
    const glutenPizza = document.getElementById("myGluten").value.trim();
    const token = sessionStorage.getItem("token");

    myHeaders.append("Authorization", "Bearer " + token);
    var myHeaders = new Headers();
     myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
    "name": namePizza,
    "gluten": (glutenPizza === 'true') ,
    "id": parseInt(idPizza)
    });

var requestOptions = {
  method: 'PUT',
  headers: myHeaders,
  body: raw,
  redirect: 'follow'
};

fetch(`${basicUrl}${id}`, requestOptions)
  .then(response => response.text())
  .then(result => console.log(result))
  .catch(error => console.log('error', error));
}


