REM To use this script you should set your docker hub id. This script work only on windows muchine.
SET DOCKERHUBID=berart

docker build -f src\WebPortal\Portal\Dockerfile -t %DOCKERHUBID%/webportal .

docker build -f src\Supportal\Portal\Dockerfile -t %DOCKERHUBID%/supportal .

docker pull rabbitmq

docker build -f src\BookingService\API\Dockerfile -t %DOCKERHUBID%/bookingapi .

docker build -f src\BillingService\API\Dockerfile -t %DOCKERHUBID%/billingapi .

docker build -f src\HotelService\API\Dockerfile -t %DOCKERHUBID%/hotelapi .

docker build -f src\CarRentService\API\Dockerfile -t %DOCKERHUBID%/carrentapi .

docker build -f src\AirlineService\API\Dockerfile -t %DOCKERHUBID%/airlineapi .