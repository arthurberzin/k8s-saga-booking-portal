::kubectl create secret generic mssql --from-literal=SA_PASSWORD="5x0i9OgD1fLlMm1mbM2R6rdQ&@!B8DfSrrjBYIys"

kubectl apply -f ./deploy-communication-layer.yaml
kubectl apply -f ./deploy-services.yaml

kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.7.1/deploy/static/provider/aws/deploy.yaml
timeout /t 60 >nul
kubectl apply -f ./ingress-srv.yaml