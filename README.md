# RabbitmqExemple
Criando aplicação exemplo com Rabbitmq

# Comando para rodar o Rabbitmq com docker
docker run -d --hostname rabbitserver --name rabbitmq-server -p 15672:15672 -p 5672:5672 rabbitmq:3-management
