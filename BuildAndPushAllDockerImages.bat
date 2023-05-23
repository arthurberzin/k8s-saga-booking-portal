REM To use this script you should set your docker hub id. This script work only on windows muchine.
SET DOCKERHUBID=<DOCKERHUBID>

docker buildx build --platform linux/amd64 --push -f src\WebPortal\Portal\Dockerfile -t %DOCKERHUBID%/webportal .

docker buildx build --platform linux/amd64 --push -f src\Supportal\Portal\Dockerfile -t %DOCKERHUBID%/supportal .

docker pull rabbitmq

docker buildx build --platform linux/amd64 --push -f src\BookingService\API\Dockerfile -t %DOCKERHUBID%/bookingapi .

docker buildx build --platform linux/amd64 --push -f src\BillingService\API\Dockerfile -t %DOCKERHUBID%/billingapi .

docker buildx build --platform linux/amd64 --push -f src\HotelService\API\Dockerfile -t %DOCKERHUBID%/hotelapi .

docker buildx build --platform linux/amd64 --push -f src\CarRentService\API\Dockerfile -t %DOCKERHUBID%/carrentapi .

docker buildx build --platform linux/amd64 --push -f src\AirlineService\API\Dockerfile -t %DOCKERHUBID%/airlineapi .