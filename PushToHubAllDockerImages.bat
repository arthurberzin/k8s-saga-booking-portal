REM To use this script you should set your docker hub id. This script work only on windows muchine.
SET DOCKERHUBID=berart

docker push %DOCKERHUBID%/webportal

docker push %DOCKERHUBID%/supportal

docker push %DOCKERHUBID%/bookingapi

docker push %DOCKERHUBID%/billingapi

docker push %DOCKERHUBID%/hotelapi

docker push %DOCKERHUBID%/carrentapi

docker push %DOCKERHUBID%/airlineapi