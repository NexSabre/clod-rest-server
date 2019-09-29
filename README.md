# CLOD Rest Server
"Cliffs of Dover Rest Server" is a tool designed to transfer a data from NamedMemory into Arduino based controller thru HTTP Rest API. 

## How to run a project
Run `clod-rest-server.exe`. Information shall be available on `localhost:5000/planeinformation`.

## How information on REST API looks like
`GET` on `localhost:5000` shall return:
```json
{"version":"0.1","planeInformation":{"i_EngineRPM":null,"i_EngineManPress":0,"i_EngineBoostPress":0,"i_EngineWatPress":0,"i_EngineOilPress":0,"i_EngineFuelPress":0,"i_EngineWatTemp":0,"i_EngineRadTemp":0,"i_EngineOilTemp":0,"i_EngineOilRadiatorTemp":0,"i_EngineTemperature":0,"i_EngineCarbTemp":0}}
```

_NOTE_: All this schema will be changed in the future, also version 0.1 will be constant thru entire development process. It will be changed after adding all data.