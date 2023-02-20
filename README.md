# Coords (API part 1)
API part of microservice project.
Solution use: 
* RabbitMQ for sending communicate with another microservices.

Full project contains:
* [Coords API (part 1)](https://github.com/Unguryan/Coords_API_p1)
* [Confirm Coords API (part 2)](https://github.com/Unguryan/Coords_Confirm_p2)
* [Angular (part 3)](https://github.com/Unguryan/Coords_Angular_p3)
* [Telegram Service (part 4)](https://github.com/Unguryan/Coords_Telegram_p4)

# Installation

* For Default install: just run the project.
* For using in Docker container: 

Create network:
    
```bash
PM> docker network create coords_net 
```

Run Rabbit in docker:
    
```bash
PM> docker run -d --network coords_net --hostname rabbitmqhost --name rabbit_coords -p 5672:5672 -p 15672:15672 rabbitmq:management
```

Also need:
* Add new Virtual Host: "CoordsVH"
* AddUsers: ApiService, ConfirmService, TelegramService


Build up:
    
```bash
PM> docker-compose up
```


