# develop stage
FROM node:12.13.0-alpine as develop-stage
WORKDIR /
COPY package*.json ./

RUN yarn install 
COPY . .
EXPOSE 3000
CMD ["yarn", "run", "start"]