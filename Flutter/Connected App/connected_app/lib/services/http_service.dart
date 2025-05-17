
import 'api_service.dart';
import '../models/post.dart';

class HttpService {
  final ApiService _apiService;

  HttpService({required ApiService apiService}) : _apiService = apiService;

  Future<Post> getPost() async {
    final postData = await _apiService.get('/posts/1');
    return Post.fromJson(postData);
  }

  Future<void> createPost(Post post) async {
    await _apiService.post('/posts', post.toJson());
  }

  Future<void> updatePost(Post post) async {
    await _apiService.put('/posts/${post.id}', post.toJson());
  }

  Future<void> patchPost(Post post) async {
    await _apiService.patch('/posts/${post.id}', {'title': post.title});
  }

  Future<void> deletePost(int postId) async {
    await _apiService.delete('/posts/$postId');
  }
}
