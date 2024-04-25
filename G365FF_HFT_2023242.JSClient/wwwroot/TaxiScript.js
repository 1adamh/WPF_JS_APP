let taxis = [];
getdatataxi();
//fetch('http://localhost:12932/taxi')
//    .then(x => x.json())
//    .then(y => {
//        taxis = y;
//        console.log(taxis);
//        display();
//    });
async function getdatataxi() {
    await fetch('http://localhost:12932/taxi')
        .then(x => x.json())
        .then(y => {
            taxis = y;
            console.log(taxis);
            displaytaxi();
        });
}

function displaytaxi() {
    taxis.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.tid + "</td><td>"
            + t.name + "<td><td>" + `<button type="button" onclick="remove(${t.tid})>Delete</button>` + "</td><td>";

        //console.log(t.Name)
    })
}

function createtaxi() {
    let name = document.getElementById('taxiname').value;
    fetch('http://localhost:12932/taxi', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatataxi();
        })
        .catch((error) => { console.error('Error:', error); });

}