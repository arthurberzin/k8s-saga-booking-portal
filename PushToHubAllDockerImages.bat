REM To use this script you should set your docker hub id. This script work only on windows muchine.
SET DOCKERHUBID=<docker hub id>

docker push %DOCKERHUBID%/webportal

docker push %DOCKERHUBID%/supportal

docker push %DOCKERHUBID%/bookingapi

docker push %DOCKERHUBID%/aggregatorgapi

docker push %DOCKERHUBID%/hotelapi

docker push %DOCKERHUBID%/carrentapi

docker push %DOCKERHUBID%/airlineapi