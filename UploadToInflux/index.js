const express = require('express');
const bodyParser = require('body-parser');
const Influx = require("influx");
const cors = require('cors');
var mqtt = require('mqtt')
var client  = mqtt.connect('tcp://test.mosquitto.org')

let app = express();

let Host='192.168.220.93';
let Port=8086; 
let Targa;

app.use(cors());

client.on('connect', function () {                              //MQTT
  client.subscribe('kitt/+/telemetry', function (err) {        //subscribe to topic kitt/_targa_/telemetria
    if (err) {
        console.log(err);
    } 
    if (!err) {
        console.log('sottoscritto al topic con successo');  
    }
  })
})
 
client.on('message', function (topic, message) {                //MQTT
    //message is Buffer
    //parse(message.toString());
     
    console.log('messaggio ricevuto stringato: '+message.toString());
    upload(topic, message);
    //console.log(topic.toString());
})



function upload(topic, message){
//function upload(){                                              //MIA FUNZIONE
    
    //let message = '{ "temperature": 36.1672660318051, "speed": 76.2265260919121,  "position": {  "latitude" : 24.2495037402257, "longitude": -17.7107477549979 }, "direction": -142.712545489293}';

    var msg = JSON.parse(message);
    //console.log(msg);
    var arrTop = topic.split("/");
    
    Targa = arrTop[1];

    console.log('targa: '+targa);
    
    let arrayMeasurment = [msg.temperature, msg.speed,msg.position.latitude,msg.position.longitude,msg.direction];
    let arrayFields = ['temperature', 'speed','latitude','longitude','direction'];    

    for(let i=0;i<arrayFields.length;i++){
        
        influx.writePoints([                            //CARICAMENTO SU INFLUX
            {
            measurement: arrayMeasurment[i],
            fields: arrayFields[i],
            //tags: ,
            //timestamp: 
            }
        ])
        .catch(error => { 
            console.log(error);
            res.sendStatus(500);
         });
    }

}

const influx = new Influx.InfluxDB({                            //CONNESSIONE INFLUX    
    host:Host,
    database:Targa,
    port:Port,
});
 

app.listen(8000, () => {                                    //QUESTA TI SERVE
    console.log("App in ascolto sulla porta 8000");
    //upload();
    
});

