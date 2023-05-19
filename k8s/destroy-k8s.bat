kubectl delete deployment mssql-bk-depl -n booking-nm
kubectl delete service mssql-bk-clusterip-srv -n booking-nm
kubectl delete pvc mssql-bk-claim -n booking-nm

kubectl delete deployment hotels-service -n booking-nm
kubectl delete service hotels-clusterip-srv -n booking-nm

kubectl delete deployment car-rent-service -n booking-nm
kubectl delete service car-rent-clusterip-srv -n booking-nm

kubectl delete deployment airlines-service -n booking-nm
kubectl delete service airlines-clusterip-srv -n booking-nm

kubectl delete ingress webportal-ingress -n booking-nm

kubectl delete deployment webportal-depl -n booking-nm
kubectl delete service webportal-clusterip-srv -n booking-nm
kubectl delete service webportal-srv -n booking-nm


kubectl delete secret mssql -n booking-nm


kubectl delete namespace booking-nm

kubectl delete namespace ingress-nginx
