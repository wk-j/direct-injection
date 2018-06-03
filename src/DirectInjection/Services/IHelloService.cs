namespace DirectInjection.Services {
    public interface IHelloService {
        string SayHello();
    }
    public class HelloService : IHelloService {
        public string SayHello() => "Hello";
    }

    public interface IGoodbyeService {
        string SayGoodBye();
    }

    public class GoodbyeService : IGoodbyeService {
        public string SayGoodBye() => "Byte";
    }
}