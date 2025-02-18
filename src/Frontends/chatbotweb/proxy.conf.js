module.exports = {
  "/apichatbot": {
    target:
      process.env["services__api-chatbot__http__0"] ||
      process.env["services__api-chatbot__https__0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/apichatbot": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },

  "/seq": {
    target:
      process.env["ConnectionStrings__seq"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/seq": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },

  "/ollama": {
    target:
      process.env["ConnectionStrings__ollama-container"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite: {
      "^/ollama": ""
    },
    changeOrigin: true,
    logLevel: "debug"
  },
};
console.debug(module.exports); 
