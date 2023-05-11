REM To use this script you should set your docker hub id. This script work only on windows muchine.
SET DOCKERHUBID=<docker hub id>

docker run --name webportal -p 8080:80 -d %DOCKERHUBID%/webportal

docker run --name supportal -p 8070:80 -d %DOCKERHUBID%/supportal

docker run -d --hostname my-rabbit --name booking-rabbit -p 8660:15672 -p 8060:5672 rabbitmq:3-management

docker run --name bookingapi -p 8050:80 -d %DOCKERHUBID%/bookingapi

docker run --name billingapi -p 8040:80 -d %DOCKERHUBID%/billingapi

docker run --name hotelapi -p 8030:80 -d %DOCKERHUBID%/hotelapi

docker run --name carrentapi -p 8020:80 -d %DOCKERHUBID%/carrentapi

docker run --name airlineapi -p 8010:80 -d %DOCKERHUBID%/airlineapi