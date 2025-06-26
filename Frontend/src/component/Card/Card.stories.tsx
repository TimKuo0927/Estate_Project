import type { Meta, StoryObj } from '@storybook/react';
import Card from './Card';

const meta: Meta<typeof Card> = {
  title: 'Component/Card',
  component: Card,
  tags: ['autodocs'],
  argTypes: {
    onLikeClick: { action: 'liked' },
    onCardClick: { action: 'card clicked' },
  },
};

export default meta;
type Story = StoryObj<typeof Card>;

export const Default: Story = {
  args: {
    Address: '123 Main St, Springfield',
    Price: '$450,000',
    EmployeeName: 'Jane Doe',
    imgSrc:
      'https://images.unsplash.com/photo-1745761412274-5303bc3f2e45?q=80&w=2070&auto=format&fit=crop',
    onCardClick: () => {}, // Can also be handled via action
    onLikeClick: () => {},
  },
};
