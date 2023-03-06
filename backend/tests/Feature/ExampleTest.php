<?php

namespace Tests\Feature;

use Illuminate\Foundation\Testing\RefreshDatabase;
//use Illuminate\Foundation\Testing\WithoutMiddleware;
use Tests\TestCase;

use App\Models\User;

class ExampleTest extends TestCase
{
    /**
     * A basic test example.
     *
     * @return void
     */
    public function test_the_application_returns_a_successful_response()
    {

        $user = User::factory()->create();
        
        $response = $this->actingAs($user)
                         ->withSession(['banned' => false])
                         ->get('/');


        $response = $this->get('/');

        $response->assertStatus(200);
    }
}
