let passengers = [];

getdata();
//function async getdata() {
//   await fetch('http://localhost:12932/passenger')
//        .then(x => x.json())
//        .then(y => {
//            passengers = y;
//            //console.log(passengers);
//            display();
//        });
//}
async function getdata() {
    await fetch('http://localhost:12932/passenger')
        .then(x => x.json())
        .then(y => {
            passengers = y;
            
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    passengers.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.pid + "</td><td>"
            + t.name + "<td><td>" + `<button type="button" onclick= remove(${t.pid})>Delete</button>` +"</td><td>" ;
            
        //console.log(t.Name)
    })
}
//function create() {
//    let name = document.getElementById('passengername').value;
//    console.log(name);
//    let vmi = JSON.stringify(
//        {
//            Name: name,

//        });
//    console.log(vmi);
//    fetch('http://localhost:12932/passenger', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json',
//        },
//        body: vmi,
//    })
//        .then(response => response)
//        .then(data => {
//            console.log('Success:', data);
//            getdata();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });   
//}


function create() {
    let name = document.getElementById('passengername').value;
    fetch('http://localhost:12932/passenger', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
function remove(id) {
    fetch('http://localhost:12932/passenger' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}